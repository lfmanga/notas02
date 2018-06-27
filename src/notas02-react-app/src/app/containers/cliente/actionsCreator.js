import { FETCH_ALL, FETCH_FILTER, FETCH_BY_ID } from './actionsType'
import * as service from './service'

export const fetchAll = () => {
    return (dispatch) => {
        return service.fetchAll()
            .then(result => dispatch({ type: FETCH_ALL, payload: result }))
    }
}

export const fetchFilter = (filter) => {
    return (dispatch) => {
        return service.fetchFilter(filter)
            .then(result => dispatch({ type: FETCH_FILTER, payload: result }))
    }
}

export const fetchById = (id) => {
    return (dispatch) => {
        return service.fetchById(id)
            .then(result => dispatch({ type: FETCH_BY_ID, payload: result }))
    }
}