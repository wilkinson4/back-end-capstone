import React from 'react';
import { useHistory } from 'react-router-dom';

function ItineraryCard(props) {
    const history = useHistory();

    function viewItineraryDetails() {
        history.push(`/itineraries/${props.itinerary.id}`)
    }

    return (
        <div className="itineraryCard__div">
            <h2>{props.itinerary.name}</h2>
            <p>{props.itinerary.dateOfEvent}</p>
            <p>{`${props.itinerary.city}, ${props.itinerary.state}`}</p>
            <button onClick={() => viewItineraryDetails()} id={props.itinerary.id}>View Details</button>
        </div>
    )
}

export default ItineraryCard;