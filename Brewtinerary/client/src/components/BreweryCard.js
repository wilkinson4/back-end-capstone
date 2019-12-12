import React, { useCallback } from 'react';
import { useHistory } from 'react-router-dom';

function BreweryCard(props) {
    const history = useHistory()

    const onClick = useCallback(() => {
        history.push("/breweries/add")
        return props.stateHandler("currentBrewery", props.brewery)
    }, [props, history])


    return (
        <div className="breweryCard__div">
            <div className="cardHeader__div">
                <h3 className="brewery__h3">{props.brewery.name}</h3>
                <button
                    onClick={onClick}>
                    Add To Itinerary
                    </button>
            </div>
            <div className="cardBody__div">
                <p>{props.brewery.street}, {props.brewery.city}, {props.brewery.state}, {props.brewery.postal_code}</p>
                <p>{props.brewery.phone}</p>
                <a
                    href={props.brewery.website_url}
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Website
                </a>
            </div>
        </div>
    )
}

export default BreweryCard