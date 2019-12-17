import React, { useState, useCallback } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';


function Header(props) {

  const [searchText, updateSearchText] = useState("")
  const history = useHistory()

  const onKeyUp = useCallback((event) => {
    // If the user pushes the enter key
    if(event.key === "Enter") {
      // redirect them to the breweries page
      history.push("/breweries")
      // initiate the brewery search and save them to the state of App.js
      props.stateHandler("brewerySearchText", searchText)
    }
     return null
  } , [props, searchText, history])

  return (
    <nav className="header">
      <ul className="nav-items">
        <li className="nav-item">
          <Link to="/">Home</Link>
        </li>
      </ul>
      <ul className="nav-items">
        {
          props.user ? (
            <>
              <li>
                <input
                  id="brewerySearchText"
                  name="brewerySearchText"
                  className="brewerySearch__input"
                  type="text"
                  placeholder="Search For Breweries"
                  // update the state of searchText when the user types in the input
                  onChange={(event) => {
                    const { value } = event.target;
                    updateSearchText(value)
                  }
                  }
                  // only search for breweries when the user presses the Enter key
                  onKeyUp={onKeyUp}
                />
              </li>
              <li className="brewerySearch__li">
                <Link className="brewerySearch__link" to="/breweries" onClick={() => props.stateHandler("brewerySearchText", searchText)}>
                  Search
                </Link>
              </li>
              <li className="nav-item" onClick={props.logout}>Log out</li>
            </>
          ) : (
              <>
                <input type="text" placeholder="Search For Breweries" />
                <li className="nav-item">
                  <Link to="/login">Login</Link>
                </li>
                <li className="nav-item">
                  <Link to="/register">Register</Link>
                </li>
              </>
            )
        }
      </ul>
    </nav>
  )
}

export default Header;