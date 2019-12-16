import React, { Component } from 'react';
import ItineraryManager from '../API/itineraryManager';
import ItineraryCard from './Itineraries/ItineraryCard';
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
    .then(() => ItineraryManager.getAnItinerary(3))
  }

  render() {
    return (
      <>
        <h1>My Itineraries</h1>
            {
              this.props.itineraries.map(itinerary =>{
                return(
                  <ItineraryCard {...this.props} itinerary={itinerary} key={itinerary.id}/>
                )
              })
            }
        <input onChange={this.handleInputChange} id="textToFilterBy" name="textToFilterBy" type="text" placeholder="Filter the itineraries" />
        <button onClick={this.filterValues}>Submit</button>
      </>
    )
  }
}

export default Home;