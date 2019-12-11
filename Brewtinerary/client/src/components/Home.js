import React, { Component } from 'react';
import { createAuthHeaders } from '../API/userManager';
import "./css/Home.css"

class Home extends Component {
  state = {
    itineraries: [],
    textToFilterBy: ""
  }

  componentDidMount() {
    const authHeader = createAuthHeaders();
    fetch('/api/v1/itineraries', {
      headers: authHeader
    })
      .then(response => response.json())
      .then(itineraries => {
        this.setState({ itineraries: itineraries });
      });
  }

  filterValues = () => {
    const authHeader = createAuthHeaders();
    fetch(`/api/v1/itineraries?_filter=${this.state.textToFilterBy}`, {
      headers: authHeader
    }).then(response => response.json())
      .then(itineraries => {
        this.setState({ itineraries: itineraries });
      });
  }

  handleInputChange = (event) => {
    console.log("Handle input change function");
    const { name, value } = event.target;
    this.setState({
      [name]: value,
    });
  }

  render() {
    return (
      <>
        <h1>My Itineraries</h1>
        <table className="itineraries__table">
          <thead>
            <tr className="itinerary__tableRow">
              <th>Name</th>
              <th>Date</th>
              <th>Location</th>
            </tr>
          </thead>
          <tbody className="itinerary__tableBody">
            <tr>
              {
                this.state.itineraries.map(itinerary => <td>{itinerary.name}</td>)
              }
            </tr>
            <tr>
              {
                this.state.itineraries.map(itinerary => <td>{itinerary.dateOfEvent}</td>)
              }
            </tr>
            <tr>
              {
                this.state.itineraries.map(itinerary => <td>{`${itinerary.city}, ${itinerary.state}`}</td>)
              }
            </tr>
          </tbody>
        </table>
        <input onChange={this.handleInputChange} id="textToFilterBy" name="textToFilterBy" type="text" placeholder="Filter the itineraries" />
        <button onClick={this.filterValues}>Submit</button>
      </>
    )
  }
}

export default Home;