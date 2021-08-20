-- First insert all the data that doesn't depend on others

-- Users
INSERT INTO "Users" ("Username", "Password", "UserRole")
VALUES
	('admin', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=', 'administrator') -- PASSWORD IS "admin"
ON CONFLICT ("Username") DO NOTHING;

INSERT INTO "Users" ("Username", "Password") -- ALL passwords ARE "password"
VALUES
	('jdoe', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg='), -- John Doe
	('cklein', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg='), -- Calvin Klein
	('madams', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg='), -- Marie Adams
	('ljenkins', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg='), -- Leeroooy Jeeeenkiiinss!
	('dvader', 'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=') -- Darth Vader
ON CONFLICT ("Username") DO NOTHING;

-- EmergencyContacts
DELETE FROM "EmergencyContacts" *;

INSERT INTO "EmergencyContacts" ("Name", "Email", "HomePhoneNumber", "CellPhoneNumber")
VALUES
	('John Legend', 'jlegend@test.test', '1231231234', '8467532164'),
	('Ronald McDonald', 'rmcdonald@test.test', '1643571895', '6459481563');

INSERT INTO "EmergencyContacts" ("Name", "Email", "WorkPhoneNumber", "CellPhoneNumber")
VALUES
	('Doja Cat', 'dcat@test.test', '8467532164', '1643571895'),
	('Bob Ross', 'bross@test.test', '6459481563', '6459481563');

-- Qualifications
INSERT INTO "Qualifications" ("Type", "Label")
VALUES
	('skill', 'Construction'),
	('skill', 'Programming'),
	('skill', 'Singing'),
	('skill', 'Dancing'),
	('license', 'CPA'), -- Accounting License
	('interest', 'Music'),
	('interest', 'Dance'),
	('educationalBackground', 'College'),
	('educationalBackground', 'High School')
ON CONFLICT ("Type", "Label") DO NOTHING;

-- Centers
INSERT INTO "Centers" ("Name")
VALUES
	('West Church'),
	('Pultee Construction Site'),
	('Jax City Rescue'),
	('Catholic Charities')
ON CONFLICT ("Name") DO NOTHING;


-- Then insert all the data that depends on others

-- Opportunities
INSERT INTO "Opportunities" ("Title", "Description", "CenterID", "StartsAt", "EndsAt")
VALUES
	('Music for Change', 'A music show to collect donations for the homeless.', 1, '2021-10-23 18:00:00', '2021-10-23 20:00:00'),
	('Code for Charities', 'Build a VMS for Jax City Rescue and help the homeless.', 3, '2021-08-23 16:00:00', '2021-08-23 20:00:00'),
	('Affordable Accounting Advice', 'Volunteer to provide affordable accounting advice for those in need.', 4, '2021-07-26 17:00:00', '2021-07-26 19:00:00'),
	('Help Pultee build affordable housing', 'Volunteer to build some houses.', 2, '2021-10-23 08:00:00', '2021-10-23 17:00:00')
ON CONFLICT ("Title") DO NOTHING;

-- OpportunityRequirements
INSERT INTO "OpportunityRequirements" ("OpportunityID", "QualificationID")
VALUES
	(1, 3),
	(1, 6),
	(2, 2),
	(2, 8),
	(3, 5),
	(4, 1)
ON CONFLICT ("OpportunityID", "QualificationID") DO NOTHING;

-- Volunteers
DELETE FROM "Volunteers" *;

INSERT INTO "Volunteers" ("UserID", "FirstName", "LastName", "Email", "EmergencyContactID")
VALUES
	(1, 'John', 'Doe', 'jdoe@test.test', 1),
	(2, 'Calvin', 'Klein', 'cklein@test.test', 2);

INSERT INTO "Volunteers" ("UserID", "FirstName", "LastName", "Email", "EmergencyContactID", "Approved")
VALUES
	(3, 'Marie', 'Adams', 'madams@test.test', 3, 1),
	(4, 'Leroy', 'Jenkins', 'ljenkins@test.test', 4, 1),
	(5, 'Darth', 'Vader', 'dvader@test.test', NULL, 2);

-- CenterPreferences
DELETE FROM "CenterPreferences" *;

INSERT INTO "CenterPreferences" ("VolunteerID", "CenterID")
VALUES
	(1, 1)
ON CONFLICT ("VolunteerID", "CenterID") DO NOTHING;

-- VolunteerQualifications
DELETE FROM "VolunteerQualifications" *;

INSERT INTO "VolunteerQualifications" ("VolunteerID", "QualificationID")
VALUES
	(1, 3),
	(1, 6),
	(4, 2),
	(4, 8),
	(3, 5),
	(2, 1)
ON CONFLICT ("VolunteerID", "QualificationID") DO NOTHING;

-- AvailabilityTimes
DELETE FROM "AvailabilityTimes" *;

INSERT INTO "AvailabilityTimes" ("VolunteerID", "StartTime", "EndTime")
VALUES
	(1, '17:00:00', '21:00:00'),
	(2, '05:00:00', '18:00:00'),
	(3, '14:00:00', '20:00:00'),
	(4, '15:00:00', '21:00:00')
ON CONFLICT ("VolunteerID", "StartTime", "EndTime") DO NOTHING;

