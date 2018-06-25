import { FETCH_ALL, FETCH_FILTER, FETCH_BY_ID } from './actionsType'

const initialState = {
    list: [],
    model: {}
}

export default (state = initialState, action) => {
    switch (action.type) {
        case FETCH_ALL:
            return Object.assign({}, state, { list: action.payload })
        case FETCH_FILTER:
            return Object.assign({}, state, { list: action.payload })
        case FETCH_BY_ID:
            return Object.assign({}, state, { model: action.payload })
        default:
            return state;
    }
}