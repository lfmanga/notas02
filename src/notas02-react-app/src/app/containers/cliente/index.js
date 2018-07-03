import React from 'react'
import { connect } from 'react-redux'
import { fetchAll, fetchFilter, fetchById } from './actionsCreator'
import { bindActionCreators } from 'redux'

import Content from '../../components/layout/content'
import Modal from '../../components/cliente/modal.edit'

import Search from '../../components/cliente/search'
import Table from '../../components/cliente/table'
import Axios from 'axios';

const initialState = {
    list: [],
    data: {}
}

class Cliente extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            list: [],
            searchText: '',
            data: {
                id: '',
                nome: ''
            }
        }
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ list: nextProps.list })
    }

    render() {
        return (
            <div className="container-fluid">
                <Content>
                    <Search
                        searchTitle="Search"
                        searchText={this.state.searchText}
                        handleSearch={this.handleSearch.bind(this)}
                        handleSearchTextChanged={this.handleSearchTextChanged.bind(this)}
                    />

                    <div className="container-fluid">
                        <div className="card">
                            <div className="card-header">
                                <h5>Result</h5>
                            </div>
                            <div className="card-body">
                                <Table list={this.state.list} />
                            </div>
                        </div>
                    </div>

                    <Modal
                        isOpen={false}
                        data={this.state.data}
                        handleTextChanged={this.handleTextChanged.bind(this)}
                        handleButtonSave={this.handleButtonSave.bind(this)}
                    />
                </Content>
            </div>
        )
    }

    handleSearch() {
        this.props.actions.fetchAll()
    }

    handleSearchTextChanged(searchText) {
        this.setState({ searchText })
    }

    handleTextChanged(e) {
        let data = this.state.data
        data[e.target.name] = e.target.value
        this.setState({ data })
    }

    handleButtonSave() {
        let data = this.state.data
        Axios.post('http://localhost:5000/api/cliente'
            , data
            , {
                headers: {
                    'Content-Type': 'application/json',
                }
            }).then((response) => {
                console.log(response)
            })
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