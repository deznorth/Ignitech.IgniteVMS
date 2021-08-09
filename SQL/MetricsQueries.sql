
-- Get up to 5 upcoming opportunities
SELECT *
FROM dbo."Opportunities" o
WHERE "EndsAt" > NOW()
ORDER BY "StartsAt" ASC
LIMIT 5

-- Get counts for volunteer approval statuses
SELECT
	COUNT(*) FILTER (WHERE "Approved" IS NULL) AS "PendingVolunteers",
	COUNT(*) FILTER (WHERE "Approved" = 1::boolean) AS "ApprovedVolunteers",
	COUNT(*) FILTER (WHERE "Approved" = 0::boolean) AS "DeniedVolunteers"
FROM dbo."Volunteers" v
