-- Creating tables that don't depend on any other tables first.

-- Users
CREATE TABLE IF NOT EXISTS "Users" (
	"UserID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Username" varchar(40) NOT NULL UNIQUE,
	"Password" varchar(128) NOT NULL,
	"UserRole" "UserRole" NOT NULL DEFAULT 'volunteer'
);

-- EmergencyContacts
CREATE TABLE IF NOT EXISTS "EmergencyContacts" (
	"ContactID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Name" varchar(70) NOT NULL,
	"Email" varchar(128),
	"Address" varchar(256),
	"HomePhoneNumber" varchar(30),
	"WorkPhoneNumber" varchar(30),
	CONSTRAINT chk_phones CHECK ("HomePhoneNumber" IS NOT NULL OR "WorkPhoneNumber" IS NOT NULL)
);

-- Qualifications
CREATE TABLE IF NOT EXISTS "Qualifications" (
	"QualificationID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Type" "QualificationType" NOT NULL,
	"Label" varchar(128) NOT NULL,
	UNIQUE ("Type", "Label")
);

-- Centers
CREATE TABLE IF NOT EXISTS "Centers" (
	"CenterID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Name" varchar(70) NOT NULL UNIQUE
);

-- Creating tables that depend on other tables

-- Volunteers
CREATE TABLE IF NOT EXISTS "Volunteers" (
	"VolunteerID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"UserID" int REFERENCES "Users" ON DELETE CASCADE NOT NULL,
	"FirstName" varchar(35) NOT NULL,
	"LastName" varchar(35) NOT NULL,
	"Email" varchar(128) NOT NULL,
	"HomePhoneNumber" varchar(30),
	"WorkPhoneNumber" varchar(30),
	"CellPhoneNumber" varchar(30),
	"Address" varchar(256),
	"EmergencyContactID" int REFERENCES "EmergencyContacts" ("ContactID"),
	"DriversLicenseFiled" boolean NOT NULL DEFAULT FALSE,
	"SSNOnFile" boolean NOT NULL DEFAULT FALSE,
	"Approved" int NOT NULL DEFAULT 0, -- 0 = Pending, 1 = Approved, 2 = Denied
	"CreatedAt" timestamp NOT NULL DEFAULT NOW(),
	"UpdatedAt" timestamp,
	CONSTRAINT chk_approved CHECK ("Approved" IN (0, 1, 2))
);

-- AvailabilityTimes
CREATE TABLE IF NOT EXISTS "AvailabilityTimes" (
	"AvailabilityTimeID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"VolunteerID" int REFERENCES "Volunteers" ON DELETE CASCADE NOT NULL,
	"StartTime" time NOT NULL,
	"EndTime" time NOT NULL,
	CONSTRAINT chk_time CHECK ("StartTime" < "EndTime"),
	UNIQUE ("VolunteerID", "StartTime", "EndTime")
);

-- VolunteerQualifications
CREATE TABLE IF NOT EXISTS "VolunteerQualifications" (
  "VolunteerQualificationID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "VolunteerID" int REFERENCES "Volunteers" ON DELETE CASCADE NOT NULL,
  "QualificationID" int REFERENCES "Qualifications" ON DELETE CASCADE NOT NULL,
  UNIQUE ("VolunteerID", "QualificationID")
);

-- CenterPreferences
CREATE TABLE IF NOT EXISTS "CenterPreferences" (
  "CenterPreferenceID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "VolunteerID" int REFERENCES "Volunteers" ON DELETE CASCADE NOT NULL,
  "CenterID" int REFERENCES "Centers" ON DELETE CASCADE NOT NULL,
  UNIQUE ("VolunteerID", "CenterID")
);

-- Opportunities
CREATE TABLE IF NOT EXISTS "Opportunities" (
  "OpportunityID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "Title" varchar(128) NOT NULL UNIQUE,
  "Description" varchar(512) NOT NULL,
  "CenterID" int REFERENCES "Centers" ON DELETE CASCADE NOT NULL,
  "StartsAt" timestamp NOT NULL,
  "EndsAt" timestamp NOT NULL,
  "CreatedAt" timestamp NOT NULL DEFAULT NOW(),
  CONSTRAINT chk_timestamps CHECK ("StartsAt" < "EndsAt")
);

-- OpportunityRequirements
CREATE TABLE IF NOT EXISTS "OpportunityRequirements" (
  "OpportunityRequirementID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "OpportunityID" int REFERENCES "Opportunities" ON DELETE CASCADE NOT NULL,
  "QualificationID" int REFERENCES "Qualifications" ON DELETE CASCADE NOT NULL,
  UNIQUE ("OpportunityID", "QualificationID")
);
