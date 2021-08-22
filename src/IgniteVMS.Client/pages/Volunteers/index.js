import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import * as actions from './modules/actions';

import SearchForm from './SearchForm';
import VolunteerList from './VolunteerList';



const  VolunteersPage = (props) => {
  const {
    loading,
    volunteerData,
    fetchVolunteers
  } = props;

  let [volunteerList, setVolunteerList] = useState([]);
  let [query, setQuery] = useState('');
  let [sortBy, setSortBy] = useState("firstName");
  let [orderBy, setOrderBy] = useState('asc');
 

  const filteredVolunteers = volunteerData.filter(
    item => {
      if (item.volunteerQualifications === null) {item.volunteerQualifications = ""};
      if (item.centerPreferences === null) {item.centerPreferences = ""};
      return (
        item.firstName.toLowerCase().includes(query.toLowerCase()) ||
        item.lastName.toLowerCase().includes(query.toLowerCase()) ||
        item.volunteerQualifications.toLowerCase().includes(query.toLowerCase()) ||
        item.centerPreferences.toLowerCase().includes(query.toLowerCase()) ||
        item.approved.toString().includes(query.toString())
      )
    }
  ).sort((a,b) => {
    let order = (orderBy==='asc') ? 1 : -1;
    return (
      a[sortBy] < b[sortBy] ?
      -1 * order : 1* order
    )
  })

  
  useEffect(() => {
    fetchVolunteers();
  }, []);

  return (
    <div className="App container mx-auto mt-3 font-thin">
      <h1 className="text-5xl mb-3" >Volunteer Management</h1>
      <SearchForm query={query} 
      onQueryChange={myquery => setQuery(myquery) }
      orderBy={orderBy}
      onOrderByChange={mySort => setOrderBy(mySort)}
      sortBy={sortBy}
      onSortByChange={mySort => setSortBy(mySort)}
      />
      <div className="table-responsive">
      <table className="table table-striped table-sm table-bordered">
        <thead>
          <tr>
            <th>Full Name</th>
            <th>Center Preferences</th>
            <th>Qualifications</th>
            <th>DL Filed</th>
            <th>SSN Filed</th>
            <th>Approved</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
      
        {filteredVolunteers
        .map(volunteerData => (
          <VolunteerList key={volunteerData.volunteerID}
          volunteer={volunteerData}/>
          ))
        }
                </tbody>
      </table>
      </div>
    </div>
  );
}

export default connect(
  state => ({
    ...state.pages.volunteers,
  }), {
    fetchVolunteers: actions.fetchVolunteers  }
)(VolunteersPage);
