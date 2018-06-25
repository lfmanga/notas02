import React from 'react'
import { connect } from 'react-redux'
import { fetchAll, fetchFilter, fetchById } from './actionsCreator'
import { bindActionCreators } from 'redux'

import Content from '../../components/layout/content/cliente'

class Cliente extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            list: [],
            filterText: ''
        }
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ list: nextProps.list })
    }

    render() {
        return (
            <div className="container-fluid">
                <Content
                    list={this.state.list}
                    onSearch={this.onSearch.bind(this)}
                    filterText={this.state.filterText}
                    onChangeFilterText={this.onChangeFilterText.bind(this)}
                />
            </div>
        )
    }

    onChangeFilterText(filterText) {
        this.setState({ filterText })
    }

    onSearch() {
        if(this.state.filterText)  this.props.actions.fetchFilter(this.state.filterText)
        else this.props.actions.fetchAll()
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
            fetchFilter : fetchFilter
        }, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Cliente)