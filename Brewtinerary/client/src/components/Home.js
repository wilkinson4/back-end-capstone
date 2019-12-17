import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import ItineraryManager from '../API/itineraryManager';
import ItineraryCard from './Itineraries/ItineraryCard';
import "./css/Home.css";

class Home extends Component {
  state = {
    loadingStatus: true
  }

  componentDidMount() {
    ItineraryManager.getAllItineraries()
      .then(itineraries => {
        this.props.stateHandler("itineraries", itineraries)
      })
      .then((this.setState({loadingStatus: false})))
  }

  render() {
    return (
      <>
        <h1>My Itineraries</h1>
        <button onClick={() => this.props.history.push("/itineraries/create")}>Create Itinerary</button>
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

export default withRouter(Home);