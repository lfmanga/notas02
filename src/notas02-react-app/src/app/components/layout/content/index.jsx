import React from 'react'

export default ({ children }) => (
    <div className="container-fluid">
        {children ? children : 'No Content Found'}
    </div>
)