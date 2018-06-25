import React from 'react'
import { connect } from 'react-redux'
import { fetchAll, fetchById } from './actionsCreator'
import { bindActionCreators } from 'redux'

import Table from '../../components/cliente/Table'
import EditModal from '../../components/cliente/EditModal'
import FormCliente from '../../components/cliente/FormCliente'

class Cliente extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            list: [],
            model: {},
            isOpenEditModal: false
        }
        this.props.actions.fetchAll() //remover isso        
    }

    componentWillReceiveProps(nextProps) {
        this.setState({ list: nextProps.list, model: nextProps.model ? nextProps.model : {} })
    }

    handleClickListAll() {
        this.props.actions.fetchAll()
    }

    handleClickEdit(id) {
        this.props.actions.fetchById(id)
        this.setState({ isOpenEditModal: true })
    }

    toggleEditModal() {
        this.setState({ isOpenEditModal: !this.state.isOpenEditModal })
    }


    render() {

        const { model } = this.state

        return (
            <div className="container-fluid">
                <h1>Hello Cliente</h1>
                <button
                    className="btn btn-primary"
                    onClick={this.handleClickListAll.bind(this)}>
                    listAll</button>
                <Table
                    list={this.state.list}
                    onClickEditButton={this.handleClickEdit.bind(this)} />
                <EditModal
                    isOpen={this.state.isOpenEditModal}
                    toggle={this.toggleEditModal.bind(this)}
                    model={model}>

                <FormCliente />

                </EditModal>
            </div>
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
            fetchById: fetchById
        }, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Cliente)