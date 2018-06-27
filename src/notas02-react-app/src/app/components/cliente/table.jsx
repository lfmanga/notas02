import React from 'react'

import Row from './table.row'

export default ({ list }) => (
    <table className="table table-stripped">
        <thead>
            <tr>
                <th style={{ width: '25%' }}>Id</th>
                <th style={{ width: '65%' }}>Nome</th>
                <th style={{ width: '10%' }}>#</th>
            </tr>
        </thead>
        <tbody>
            {list.map((data) => (<Row key={data.id} data={data} />))}
        </tbody>
    </table>
)