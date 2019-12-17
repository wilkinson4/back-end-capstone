import React, { Component } from 'react';
import ItineraryManager from '../API/itineraryManager';
import ItineraryCard from './Itineraries/ItineraryCard';
import "./css/Home.css";

class Home extends Component {
  state = {
    loadingStatus: true
  }

  componentDidMount() {
    console.log("Home.js componentDidMount called")
    ItineraryManager.getAllItineraries()
      .then(itineraries => {
        console.log("inside updating itineraries state")
        this.props.stateHandler("itineraries", itineraries)
      })
      .then((this.setState({loadingStatus: false})))
  }

  render() {
    return (
      <>
        <h1>My Itineraries</h1>
        {
          this.props.itineraries.map(itinerary => {
            return (
              <ItineraryCard
                {...this.props}
                itinerary={itinerary}
                key={itinerary.id}
                stateHandler={this.props.stateHandler}
              />
            )
          })
        }
      </>
    )
  }
}

export default Home;