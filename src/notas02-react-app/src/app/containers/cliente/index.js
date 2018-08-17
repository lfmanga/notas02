import React from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import { fetchAll, fetchFilter, fetchById } from './actionsCreator'
import Layout from '../../components/layout'

import List from './list'
import Edit from './edit'

import config from '../../../config.json'

const apiRoute = '/cliente'
const apiUrl = config.URL_API + apiRoute

class Cliente extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            id: '',
            showModal: false
        }
        this.refList = React.createRef()
    }

    handleEdit(id) {
        this.setState({ id: id, showModal: true })
    }

    render() {
        return (
            <Layout>
                <List
                    apiUrl={apiUrl}
                    handleEdit={this.handleEdit.bind(this)}
                    ref={this.refList}
                />
                <Edit
                    apiUrl={apiUrl}
                    id={this.state.id}
                    showModal={this.state.showModal}
                    refList={this.refList.current}
                />
            </Layout>
        )
    }
}

const mapStateToProps = (store) => {
    return {
        list: store.clienteReducer.list,
        model: store.clienteReducer.model
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        actions: bindActionCreators({
            fetchAll: fetchAll,
            fetchById: fetchById,
            fetchFilter: fetchFilter
        }, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Cliente)