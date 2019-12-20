import React, { useState, useEffect } from 'react';
import BreweryCard from './BreweryCard.js';
import BreweryManager from '../../API/breweryManager';
import '../css/BreweryList.css';


function BreweryList(props) {
    const [breweries, updateBreweries] = useState([])

    useEffect(() => {
        BreweryManager.getThirdPartyBreweries(props.brewerySearchText)
            .then(breweries => {
                updateBreweries(breweries)
            })
    }, [props.brewerySearchText])



    return (
        <section className="breweryList__section">
            <h1>Brewery Results</h1>
            <ol className="breweryList__ol">
                {
                    breweries.map(b => {
                        // Don't render a brewery card for breweries that have a brewery_type of "planning"
                        return b.brewery_Type !== "planning" &&
                            <li>
                                <BreweryCard {...props}
                                    brewery={b}
                                    key={b.id} 
                                    stateHandler={props.stateHandler}
                                    />
                            </li>
                    })
                }
            </ol>
        </section>
    )
}

export default BreweryList;