import { BiTrash, BiEdit } from 'react-icons/bi';



const VolunteerList = ({volunteer, onDeleteVolunteer}) => {
    return (
      <tr key={volunteer.id}>
        <td className="text-primary font-weight-bold">{volunteer.firstName} {volunteer.lastName}</td>
        <td>{volunteer.center}</td>
        <td>{volunteer.qualifications}</td>
        <td>{volunteer.driversLicenseOnFile ? "Yes" : "No"}</td>
        <td>{volunteer.sSNFiled ? "Yes" : "No"} </td>
        <td>{volunteer.status === 0 ? "Pending" : volunteer.status === 1 ? "Yes" : "No"}</td>
        <td><button className="btn btn-outline-light text-dark" type="button">
           <BiEdit /></button></td>
        <td><button className="btn btn-outline-light text-dark" onClick={ () => onDeleteVolunteer(volunteer.id)} type="button">
          <BiTrash /></button></td>
          </tr>
    )
}

export default VolunteerList;