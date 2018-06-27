import React from 'react'

import Header from './header'

export default (props) => (
    <div>
        <Header />
        {props.children ? props.children : ''}
    </div>
)