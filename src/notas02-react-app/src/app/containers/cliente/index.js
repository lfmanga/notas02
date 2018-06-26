import React from 'react'
import { connect } from 'react-redux'
import { fetchAll, fetchFilter, fetchById } from './actionsCreator'
import { bindActionCreators } from 'redux'

import Content from '../../components/layout/content'
import Modal from '../../components/layout/modal'

import Search from '../../components/cliente/search'
import Table from '../../components/cliente/table'



class Cliente extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            list: [],
            searchText: ''
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
                        isOpen={true}
                        handleTogglesa={() => (console.log(arguments))}
                        titleText={'Manager'}
                        buttonSaveText={'Save'}
                        buttonCancelText={'Cancel'}
                    >
                        {/* Body Of Body */}
                    </Modal>
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