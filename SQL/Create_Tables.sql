-- Creating tables that don't depend on any other tables first.

-- Users
CREATE TABLE IF NOT EXISTS "Users" (
	"UserID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Username" varchar(40) NOT NULL,
	"Password" varchar(128) NOT NULL,
	"UserRole" "UserRole" NOT NULL DEFAULT 'volunteer'
);

-- EmergencyContacts
CREATE TABLE IF NOT EXISTS "EmergencyContacts" (
	"ContactID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Name" varchar(70) NOT NULL,
	"Email" varchar(128),
	"Address" varchar(256),
	"HomePhoneNumber" int,
	"WorkPhoneNumber" int,
	CONSTRAINT chk_phones CHECK ("HomePhoneNumber" IS NOT NULL OR "WorkPhoneNumber" IS NOT NULL)
);

-- Qualifications
CREATE TABLE IF NOT EXISTS "Qualifications" (
	"QualificationID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Type" "QualificationType" NOT NULL,
	"Label" varchar(128) NOT NULL
);

-- Centers
CREATE TABLE IF NOT EXISTS "Centers" (
	"CenterID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"Name" varchar(70) NOT NULL
);

-- Creating tables that depend on other tables

-- Volunteers
CREATE TABLE IF NOT EXISTS "Volunteers" (
	"VolunteerID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"UserID" int REFERENCES "Users" NOT NULL,
	"FirstName" varchar(35) NOT NULL,
	"LastName" varchar(35) NOT NULL,
	"Email" varchar(128) NOT NULL,
	"HomePhoneNumber" int,
	"WorkPhoneNumber" int,
	"CellPhoneNumber" int,
	"Address" varchar(256),
	"EmergencyContactID" int REFERENCES "EmergencyContacts" ("ContactID"),
	"DriversLicenseFiled" boolean NOT NULL DEFAULT FALSE,
	"SSNOnFile" boolean NOT NULL DEFAULT FALSE,
	"Approved" boolean, -- NULL means Pending Approval
	"CreatedAt" timestamp NOT NULL DEFAULT NOW(),
	"UpdatedAt" timestamp
);

-- AvailabilityTimes
CREATE TABLE IF NOT EXISTS "AvailabilityTimes" (
	"AvailabilityTimeID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
	"VolunteerID" int REFERENCES "Volunteers" NOT NULL,
	"StartTime" time NOT NULL,
	"EndTime" time NOT NULL,
	CONSTRAINT chk_time CHECK ("StartTime" < "EndTime")
);

-- VolunteerQualifications
CREATE TABLE IF NOT EXISTS "VolunteerQualifications" (
  "VolunteerQualificationID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "VolunteerID" int REFERENCES "Volunteers" NOT NULL,
  "QualificationID" int REFERENCES "Qualifications" NOT NULL
);

-- CenterPreferences
CREATE TABLE IF NOT EXISTS "CenterPreferences" (
  "CenterPreferenceID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "VolunteerID" int REFERENCES "Volunteers" NOT NULL,
  "CenterID" int REFERENCES "Centers" NOT NULL
);

-- Opportunities
CREATE TABLE IF NOT EXISTS "Opportunities" (
  "OpportunityID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "Title" varchar(128) NOT NULL,
  "Description" varchar(512) NOT NULL,
  "CenterID" int REFERENCES "Centers" NOT NULL,
  "StartsAt" timestamp NOT NULL,
  "EndsAt" timestamp NOT NULL,
  "CreatedAt" timestamp NOT NULL DEFAULT NOW(),
  CONSTRAINT chk_timestamps CHECK ("StartsAt" < "EndsAt")
);

-- OpportunityRequirements
CREATE TABLE IF NOT EXISTS "OpportunityRequirements" (
  "OpportunityRequirementID" int PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY,
  "OpportunityID" int REFERENCES "Opportunities" NOT NULL,
  "QualificationID" int REFERENCES "Qualifications" NOT NULL
);
