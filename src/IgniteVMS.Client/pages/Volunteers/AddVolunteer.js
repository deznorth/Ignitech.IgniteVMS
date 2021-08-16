import { BiCalendarPlus } from 'react-icons/bi';
import { useState } from 'react';

const AddVolunteer = ({onSendVolunteer, lastId}) => {
    const clearData = {
      firstName: "",
      lastName: "",
      userName: "",
      passWord: "",
      center: "",
      qualifications: "",
      startTime: "",
      endTime: "",
      address: "",
      homePhone: "",
      workPhone: "",
      cellPhone: "",
      email: "",
      education: "",
      licenses: "",
      emergencyContactName: "",
      emergencyContactPhone: "",
      emergencyContactEmail: "",
      emergencyContactAddress: "",
      driversLicenseOnFile: null,
      sSNFiled: null,
      status: ""
    }

    let [toggleForm, setToggleForm] = useState(false);
    let [formData, setFormData] = useState(clearData)

    function formDataPublish() {
      const volunteerInfo = {
        id: lastId + 1, 
        firstName: formData.firstName,
        lastName: formData.lastName,
        userName: formData.userName,
        passWord: formData.passWord,
        center: formData.center,
        qualifications: formData.qualifications,
        startTime: formData.startTime,
        endTime: formData.endTime,
        address: formData.address,
        homePhone: formData.homePhone,
        workPhone: formData.workPhone,
        cellPhone: formData.cellPhone,
        email: formData.email,
        education: formData.education,
        licenses: formData.licenses,
        emergencyContactName: formData.emergencyContactName,
        emergencyContactPhone: formData.emergencyContactPhone,
        emergencyContactEmail: formData.emergencyContactEmail,
        emergencyContactAddress: formData.emergencyContactAddress,
        driversLicenseOnFile: formData.driversLicenseOnFile,
        sSNFiled: formData.sSNFiled,
        status: formData.status
        }

        onSendVolunteer(volunteerInfo);
        setFormData(clearData);
        setToggleForm(!toggleForm);
    }

    return (
        <div>
        <button onClick={() => { setToggleForm(!toggleForm)}} className="">
          <div><BiCalendarPlus className="inline-block align-text-top" />  Add Volunteer</div>
        </button>
       {
           toggleForm && 
           <div className="">
           <div className="">
             <label htmlFor="firstName" className="">
               First Name
             </label>
             <div className="">
               <input type="text" name="firstName" id="firstName"
                  onChange = {(e) => {setFormData({...formData, firstName: e.target.value})}}
                  value={formData.firstName}
                  className="" />
             </div>
           </div>
   
           <div className="">
             <label htmlFor="lastName" className="">
               Last Name
             </label>
             <div className="mt-1 sm:mt-0 sm:col-span-2">
               <input type="text" name="lastName" id="lastName"
                  onChange = {(e) => {setFormData({...formData, petName: e.target.value})}}
                  value={formData.firstName}
                  className="" />
             </div>
           </div>
   

           <div className="">
             <div className="">
               <button type="submit" onClick={formDataPublish} className="">
                 Submit
               </button>
             </div>
           </div>
         </div>
       }
      </div>
  
    )
}

export default AddVolunteer;