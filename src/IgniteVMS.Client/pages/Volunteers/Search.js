import { BiSearch, BiCaretDown, BiCheck } from "react-icons/bi";
import { useState } from "react";

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
            role="menuitem">Last Name {(sortBy === 'lastName') && <BiCheck />}</button>
          <button
            onClick = {() => onSortByChange('center')}
            className="dropdown-item"
            role="menuitem">Preferred Center  {(sortBy === 'center') && <BiCheck />}</button>
          <button
            onClick = {() => onSortByChange('qualifications')}
            className="dropdown-item"
            role="menuitem">Qualifications {(sortBy === 'qualifications') && <BiCheck />}</button>
          <button
            onClick = {() => onSortByChange('status')}
            className="dropdown-item"
            role="menuitem">Status {(sortBy === 'status') && <BiCheck />}</button>
          <div className="dropdown-divider"></div>
          <button
            onClick = {() => onOrderByChange('asc')}
            className="dropdown-item"
            role="menuitem">Asc {(orderBy === 'asc') && <BiCheck />}</button>
          <button
            onClick = {() => onOrderByChange('desc')}
            className="dropdown-item"
            role="menuitem">Desc {(orderBy === 'desc') && <BiCheck />}</button>
        {/* </div> */}
      </>
  
    )
}

const Search = ({query, onQueryChange, sortBy, onSortByChange, orderBy, onOrderByChange }) => {
    let [toggleSort, setToggleSort] = useState(false);

    return (
        <div className="">
        <div className="">
          <div className="">
            <BiSearch />
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
                Sort By <BiCaretDown className="" />
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

export default Search;