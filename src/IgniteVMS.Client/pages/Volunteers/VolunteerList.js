import React from 'react';
import { Link } from 'react-router-dom';



const VolunteerList = ({volunteer}) => {
    return (
      <tr key={volunteer.id}>
        <td className="text-primary font-weight-bold">{volunteer.firstName} {volunteer.lastName}</td>
        <td>{volunteer.centerPreferences}</td>
        <td>{volunteer.volunteerQualifications}</td>
        <td>{volunteer.driversLicenseFiled ? "Yes" : "No"}</td>
        <td>{volunteer.ssnOnFile ? "Yes" : "No"} </td>
        <td>{volunteer.approved === 0 ? "Pending" : volunteer.approved === 1 ? "Approved" : "Not Approved"}</td>
        <td><button className="btn btn-outline-light text-dark" type="button">
           <Link to="/volunteerSetup" >Edit</Link></button></td>
          </tr>
    )
}

export default VolunteerList;