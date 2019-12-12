import React, { useState, useEffect } from 'react';
import BreweryCard from './BreweryCard.js';
import BreweryManager from '../API/breweryManager';


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
            <ol className="breweryList__ol">
                <li>
                    {
                        breweries.map(b => <p>{b.name}</p>)
                    }
                </li>
            </ol>
        </section>
    )
}

export default BreweryList;