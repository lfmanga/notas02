import React from 'react'
import ReactDOM from 'react-dom'
import registerServiceWorker from './registerServiceWorker'

import 'bootstrap/dist/css/bootstrap.min.css'
import '@fortawesome/fontawesome-free/css/all.css'

import createStore from './app/store'
import reducers from './app/reducers'
import middlewares from './app/middlewares'
import history from './app/routes/history'

import App from './App'

const store = createStore(reducers, middlewares)

ReactDOM.render(<App store={store} history={history} />, document.getElementById('root'))
registerServiceWorker()