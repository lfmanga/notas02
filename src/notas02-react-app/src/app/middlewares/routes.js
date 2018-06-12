import { routerMiddleware } from 'react-router-redux'
import history from '../routes/history'
const middleware = routerMiddleware(history)
export default middleware