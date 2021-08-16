import React, { useState, useEffect, useCallback } from 'react';
import { BiCalendar } from 'react-icons/bi';
import AddVolunteer from './AddVolunteer';
import Search from './Search';
import VolunteerList from './VolunteerList';

function Volunteers() {

  let [volunteerList, setVolunteerList] = useState([]);
  let [query, setQuery] = useState('');
  let [sortBy, setSortBy] = useState("firstName");
  let [orderBy, setOrderBy] = useState('asc');

  const filteredVolunteers = volunteerList.filter(
    item => {
      return (
        item.firstName.toLowerCase().includes(query.toLowerCase()) ||
        item.lastName.toLowerCase().includes(query.toLowerCase()) ||
        item.center.toLowerCase().includes(query.toLowerCase()) ||
        item.status.toString().includes(query.toString()) ||
        item.qualifications.toLowerCase().includes(query.toLowerCase())
      )
    }
  ).sort((a,b) => {
    let order = (orderBy==='asc') ? 1 : -1;
    return (
      a[sortBy] < b[sortBy] ?
      -1 * order : 1* order
    )
  })
  
  const fetchData = useCallback(() => {
    fetch('./VolunteerData.json')
    .then(response => response.json())
    .then(data => {
      setVolunteerList(data)
    });
  }, [])

  useEffect(() => {
    fetchData()
  }, [fetchData])

  return (
    <div className="App container mx-auto mt-3 font-thin">
      <h1 className="text-5xl mb-3" ><BiCalendar className="inline-block text-red-400 align-top"/>Volunteer Management</h1>
      <AddVolunteer 
        onSendVolunteer={volunteers => setVolunteerList([...volunteerList, volunteers])}
        lastId={volunteerList.reduce((max, item) => Number(item.id) > max ? Number(item.id) : max, 0)}
        />
      <Search query={query} 
      onQueryChange={myquery => setQuery(myquery) }
      orderBy={orderBy}
      onOrderByChange={mySort => setOrderBy(mySort)}
      sortBy={sortBy}
      onSortByChange={mySort => setSortBy(mySort)}
      />

      <table className="table table-striped table-sm table-responsive">
        <thead>
          <tr>
            <th>Full Name</th>
            <th>Center Preferences</th>
            <th>Qualifications</th>
            <th>DL Filed</th>
            <th>SSN Filed</th>
            <th>Approved</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
      
        {filteredVolunteers
        .map(volunteer => (
          <VolunteerList key={volunteer.id}
          volunteer={volunteer}
          onDeleteVolunteer = {
            volunteerID => 
            setVolunteerList(volunteerList.filter(volunteer => 
              volunteer.id !== volunteerID))
          }/>
          ))
        }
                </tbody>
      </table>
    </div>
  );
}

export default Volunteers;
