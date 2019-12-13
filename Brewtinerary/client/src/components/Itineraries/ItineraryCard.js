import React from 'react';

function ItineraryCard(props) {

    return (
        <div className="itineraryCard__div">
            <h2>{props.itinerary.name}</h2>
            <p>{props.itinerary.dateOfEvent}</p>
            <p>{`${props.itinerary.city}, ${props.itinerary.state}`}</p>
            <button>View Details</button>
        </div>
    )
}

export default ItineraryCard;