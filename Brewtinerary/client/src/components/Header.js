import React, { useState } from 'react';
import { Link } from 'react-router-dom';

function Header(props) {

  const [searchText, updateSearchText] = useState("")


  return (
    <nav className="header">
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
                  onChange={(event) => {
                    const { name, value } = event.target;
                    updateSearchText(value)
                  }
                  }
                />
              </li>
              <li className="brewerySearch__li">
                <Link className="brewerySearch__link" to="/breweries" onClick={() => props.stateHandler("brewerySearchText", searchText)}>
                  Submit
                </Link>
              </li>
              <li className="nav-item">Hello {props.user.username}</li>
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