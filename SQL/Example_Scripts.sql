
-- Find all approved volunteer IDs for volunteers with the programming skill
SELECT v."VolunteerID"
FROM "Volunteers" v
JOIN "VolunteerQualifications" vq ON v."VolunteerID" = vq."VolunteerID"
JOIN "Qualifications" q ON vq."QualificationID" = q."QualificationID" AND (q."Type" = 'skill' AND q."Label" = 'Programming')
WHERE v."Approved" = TRUE
