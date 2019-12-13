import { createAuthHeaders } from '../API/userManager';

const url = "/api/v1/breweries"

export default {
    getThirdPartyBreweries(searchText) {
        const authHeaders = createAuthHeaders()
        return fetch(`${url}?filterText=${searchText}`, {
            authHeaders: authHeaders
        })
            .then(response => response.json())
    }
}