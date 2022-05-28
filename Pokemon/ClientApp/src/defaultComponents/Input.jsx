import React from 'react';
import { Container } from 'reactstrap';

const Input = (props) => {
    return (
        <Container>
            <label>{props.label}</label>
            <input type="text" disabled={props.disabled} />
        </Container>
    );
}

export default Input;