import React from 'react'
import TextBox from '../../components/forms/TextBox'
export default ({onClick}) => (
    <div className="container">
        <form onSubmit={ () => false }>
            <TextBox
                title={'Email'}
                id={'email'}
                name={'email'}
                type={'email'}
            />
            <TextBox
                title={'Senha'}
                id={'senha'}
                name={'senha'}
                type={'password'}
            />
            <button 
                type="button" 
                className="btn btn-primary"
                onClick={onClick}
            >Efetuar Login</button>
        </form>
    </div>
)