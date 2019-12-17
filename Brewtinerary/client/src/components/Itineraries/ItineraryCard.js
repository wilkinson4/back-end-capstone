import React from 'react';
import { useHistory } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';
function ItineraryCard(props) {
    const history = useHistory();

    function viewItineraryDetails() {
        history.push(`/itineraries/${props.itinerary.id}`)
    }

    const deleteItinerary = () => {
        ItineraryManager.deleteItinerary(props.itinerary.id)
        .then(ItineraryManager.getAllItineraries)
        .then(itineraries => {
            props.stateHandler("itineraries", itineraries)
            history.push("/")
        })
    }

    return (
        <div className="itineraryCard__div">
            <h2>{props.itinerary.name}</h2>
            <p>{props.itinerary.shortDate}</p>
            <p>{`${props.itinerary.city}, ${props.itinerary.state}`}</p>
            <button onClick={() => viewItineraryDetails()} id={props.itinerary.id}>View Details</button>
            <button onClick={() => deleteItinerary()}>Delete Itinerary</button>
        </div>
    )
}

export default ItineraryCard;