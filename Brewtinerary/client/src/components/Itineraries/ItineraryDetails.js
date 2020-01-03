import React, {useEffect, useCallback } from "react";
import { useParams, useHistory } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';
import AddedBreweryCard from '../Breweries/AddedBreweryCard';
import MapContainer from '../GoogleMaps/MapContainer';

function ItineraryDetails(props) {
    const { itineraryId } = useParams();

    const history = useHistory();

    const getItinerary = useCallback(() => {
        ItineraryManager.getAnItinerary(itineraryId)
            .then(itinerary => {
                props.stateHandler("currentItinerary", itinerary)
            })
    }, [itineraryId, props])

    useEffect(() => {
        getItinerary()
    }, [])


    return (

        <section className="itineraryDetails__section">
            <h1>Itinerary Details Page</h1>
            <div className="itineraryDetails__div">
                <h3>{props.currentItinerary.name}</h3>
                <p>{props.currentItinerary.shortDate}</p>
                <p>{`${props.currentItinerary.city}, ${props.currentItinerary.state}`}</p>
                <button className="button" onClick={() => history.push(`/itineraries/edit/${itineraryId}`)}>Edit Itinerary</button>
            </div>
            <div className="breweryMap__div">
                {
                    !!props.currentItinerary.breweries &&
                    <MapContainer
                        {...props}
                        breweries={props.currentItinerary.breweries}
                    />
                }
            </div>
            <div className="breweryList__div">
                <h3>Breweries</h3>
                {
                    !!props.currentItinerary.breweries &&
                    props.currentItinerary.breweries.map(b => {
                        return <AddedBreweryCard
                            key={b.id}
                            {...props}
                            brewery={b}
                        />
                    })
                }
            </div>
        </section>
    )
}

export default ItineraryDetails;