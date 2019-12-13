import { createAuthHeaders } from '../API/userManager';

const url = "/api/v1/breweries"
const authHeaders = createAuthHeaders()

export default {
    getThirdPartyBreweries(searchText) {
        return fetch(`${url}?filterText=${searchText}`, {
            headers: authHeaders
        })
            .then(response => response.json())
    },
    addBreweryToItinerary(selectedItinerary, currentBrewery) {
        fetch(`/api/v1/breweries/create/${selectedItinerary.value}`, {
            method: "POST",
            headers: authHeaders,
            body: JSON.stringify(currentBrewery)
        })
    }
}