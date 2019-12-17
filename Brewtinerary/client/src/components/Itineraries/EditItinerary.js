import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';
import Moment from 'moment';

function EditItinerary(props) {
    const [itinerary, updateItinerary] = useState({name: props.currentItinerary.name , date: props.currentItinerary.dateOfEvent, city: props.currentItinerary.city, state: props.currentItinerary.state })

    const history = useHistory();

    const handleInputChange = e => {
        const { name, value } = e.target
        updateItinerary({ ...itinerary, [name]: value })
    }

    const saveChanges = () => {
        const editedItinerary = itinerary
        editedItinerary.id = props.currentItinerary.id
        editedItinerary.dateOfEvent = new Date(itinerary.date)
        ItineraryManager.editItinerary(editedItinerary.id, editedItinerary)
        .then(editedItinerary => {
            props.stateHandler("currentItinerary", editedItinerary)
            history.push("/")
        })
    }

    return (
        <section className="editItinerary__section">
            <h1>Edit Itinerary</h1>
            <div className="itineraryName__div">
                <label htmlFor="name">Name </label>
                <input type="text" name="name" id="name" defaultValue={props.currentItinerary.name} onChange={handleInputChange} />
            </div>
            <div className="itineraryDate__div">
                <label htmlFor="date">Date </label>
                <input type="date" name="date" id="date" defaultValue={Moment.utc(props.currentItinerary.dateOfEvent).format("YYYY-MM-DD")} onChange={handleInputChange} />
            </div>
            <div className="itineraryCity__div">
                <label htmlFor="city">City </label>
                <input type="text" name="city" id="city" defaultValue={props.currentItinerary.city} onChange={handleInputChange} />
            </div>
            <div className="itineraryState__div">
                <label htmlFor="state">State </label>
                <input type="text" name="state" id="state" defaultValue={props.currentItinerary.state} onChange={handleInputChange} />
            </div>
            <button onClick={() => saveChanges()}>Save Changes</button>
        </section>
    )
}

export default EditItinerary;