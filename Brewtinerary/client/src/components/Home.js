import React, { Component } from 'react';
import ItineraryManager from '../API/itineraryManager';
import "./css/Home.css";

class Home extends Component {
  state = {
    textToFilterBy: ""
  }


  handleInputChange = (event) => {
    console.log("Handle input change function");
    const { name, value } = event.target;
    this.setState({
      [name]: value,
    });
  }

  componentDidMount() {
    ItineraryManager.getAllItineraries()
    .then(itineraries => this.props.stateHandler("itineraries", itineraries))
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
            {
              this.props.itineraries.map(itinerary =>{
                return(
                  <tr>
                    <td>{itinerary.name}</td>
                    <td>{itinerary.dateOfEvent}</td>
                    <td>{`${itinerary.city}, ${itinerary.state}`}</td>
                  </tr>
                )
              })
            }
          </tbody>
        </table>
        <input onChange={this.handleInputChange} id="textToFilterBy" name="textToFilterBy" type="text" placeholder="Filter the itineraries" />
        <button onClick={this.filterValues}>Submit</button>
      </>
    )
  }
}

export default Home;