import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';

function CreateItinerary(props) {
    const [itinerary, updateItinerary] = useState({ name: "", date: "", city: "", state: "" })

    const history = useHistory();

    const handleInputChange = e => {
        const { name, value } = e.target
        updateItinerary({ ...itinerary, [name]: value })
    }

    const saveChanges = () => {
        const newItinerary = itinerary
        newItinerary.dateOfEvent = new Date(itinerary.date)
        ItineraryManager.createItinerary(newItinerary)
            .then(newItinerary => {
                history.push("/")
            })
    }

    return (
        <section className="createItinerary__section">
            <h1>Create An Itinerary</h1>
            <div className="itineraryName__div">
                <label htmlFor="name">Name </label>
                <input type="text" name="name" id="name" onChange={handleInputChange}/>
            </div>
            <div className="itineraryDate__div">
                <label htmlFor="date">Date </label>
                <input type="date" name="date" id="date" onChange={handleInputChange} />
            </div>
            <div className="itineraryCity__div">
                <label htmlFor="city">City </label>
                <input type="text" name="city" id="city" onChange={handleInputChange} />
            </div>
            <div className="itineraryState__div">
                <label htmlFor="state">State </label>
                <input type="text" name="state" id="state" onChange={handleInputChange} />
            </div>
            <button className="button" onClick={() => saveChanges()}>Create</button>
        </section>
    )
}

export default CreateItinerary;