import React from 'react'
import { AuthHttpClient } from '../../auth'

import ListComponent from '../../components/cliente/list'
import SearchComponent from '../../components/cliente/list/search'

const defaultState = {
    list: []
}

class List extends React.Component {

    constructor(props) {
        super(props)
        this.state = defaultState
    }

    componentDidMount() {
        this.reload()
    }

    handleEdit(id) {
        if (this.props.handleEdit) this.props.handleEdit(id)
    }

    reload() {
        let self = this
        AuthHttpClient()
            .get(this.props.apiUrl)
            .then(response => {
                if (response.status === 200) {
                    let list = response.data
                    self.setState({ list })
                }
            })
    }


    render() {
        return (
            <div className="container-fluid">
                <hr></hr>
                <SearchComponent />
                <ListComponent
                    list={this.state.list}
                    handleEdit={this.handleEdit.bind(this)}
                />
            </div>
        )
    }
}

export default List