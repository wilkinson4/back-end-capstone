import { createAuthHeaders } from '../API/userManager';

const url = "/api/v1/itineraries"

export default {

    getAllItineraries() {
        const authHeader = createAuthHeaders();

        return fetch(url, {
            headers: authHeader
        })
            .then(response => response.json())
    },

    getAnItinerary(id) {
        const authHeader = createAuthHeaders();

        return fetch(`${url}/${id}`, {
            headers: authHeader
        })
            .then(response => response.json())
    },

    deleteItinerary(id) {
        const authHeader = createAuthHeaders();

        return fetch(`${url}/${id}`, {
            headers: authHeader,
            method: "DELETE"
        })
            .then(response => response.json())
    },

    editItinerary(id, editedItinerary) {
        const authHeader = createAuthHeaders();

        return fetch(`${url}/${id}`, {
            headers: authHeader,
            method: "PUT",
            body: JSON.stringify(editedItinerary)
        })
            .then(response => response.json())
    },

    createItinerary(newItinerary) {
        const authHeader = createAuthHeaders();

        return fetch(`${url}/create`, {
            headers: authHeader,
            method: "POST",
            body: JSON.stringify(newItinerary)
        })
            .then(response => response.json())
    }

}