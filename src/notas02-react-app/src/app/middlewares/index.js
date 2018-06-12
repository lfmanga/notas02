import { applyMiddleware } from 'redux'
import routeMiddleware from './routes'
export default applyMiddleware(routeMiddleware)