import { FETCH_ALL_CLIENTES } from './actionsType'

const initialState = {
    clientes: []
}

export default (state = initialState, action) => {
    switch (action.type) {
        case FETCH_ALL_CLIENTES:
            return Object.assign({}, state, { clientes: action.payload })
        default:
            return state;
    }
}