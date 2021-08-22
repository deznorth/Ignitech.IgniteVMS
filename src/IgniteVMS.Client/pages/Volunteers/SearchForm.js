import React, { useState } from "react";
import { Check, CaretDownFill, Search} from 'react-bootstrap-icons';

const DropDown = ({toggle, sortBy, onSortByChange, orderBy, onOrderByChange}) => {
    if (!toggle) {
      return null;
    }
    return (
        <>
        {/* <div className="" role="menu" aria-orientation="vertical" aria-labelledby="options-menu"> */}
          <button
            onClick = {() => onSortByChange('lastName')}
            className="dropdown-item"
            role="menuitem">Last Name {(sortBy === 'lastName') && <Check />}</button>
          <button
            onClick = {() => onSortByChange('center')}
            className="dropdown-item"
            role="menuitem">Preferred Center  {(sortBy === 'centerPreferences') && <Check />}</button>
          <button
            onClick = {() => onSortByChange('qualifications')}
            className="dropdown-item"
            role="menuitem">Qualifications {(sortBy === 'volunteerQualifications') && <Check />}</button>
          <button
            onClick = {() => onSortByChange('status')}
            className="dropdown-item"
            role="menuitem">Status {(sortBy === 'approved') && <Check />}</button>
          <div className="dropdown-divider"></div>
          <button
            onClick = {() => onOrderByChange('asc')}
            className="dropdown-item"
            role="menuitem">Asc {(orderBy === 'asc') && <Check />}</button>
          <button
            onClick = {() => onOrderByChange('desc')}
            className="dropdown-item"
            role="menuitem">Desc {(orderBy === 'desc') && <Check />}</button>
        {/* </div> */}
      </>
  
    )
}

const SearchForm = ({query, onQueryChange, sortBy, onSortByChange, orderBy, onOrderByChange }) => {
    let [toggleSort, setToggleSort] = useState(false);

    return (
        <div className="">
        <div className="">
          <div className="">
            <Search />
            <label htmlFor="query" className="sr-only" />
          </div>
          <input type="text" name="query" id="query" value={query}
          onChange={(e) => {onQueryChange(e.target.value)} }
            className="" placeholder="Search" />
          <div >
            <div className="dropdown">
              <button type="button" data-toggle="dropdown"
                onClick = {()=> {setToggleSort(!toggleSort) }}
                className="btn btn-primary" id="options-menu" aria-haspopup="true" aria-expanded="true">
                Sort By <CaretDownFill className="" />
              </button>
              <DropDown 
                className="dropdown-menu"
                toggle={toggleSort}
                sortBy={sortBy}
                onSortByChange={mySort => onSortByChange(mySort)}
                orderBy={orderBy}
                onOrderByChange={myOrder => onOrderByChange(myOrder)}
              />
            </div>
          </div>
        </div>
      </div>
   
    )
}

export default SearchForm;