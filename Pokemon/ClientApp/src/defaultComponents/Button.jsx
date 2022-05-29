import React from 'react';
import styled from 'styled-components';
import { CircularProgress } from '@material-ui/core';

const Button = (props) => {
    return (
        <StyledButton onClick={props.handleOnClick} disabled={props.isLoading}>
            {props.isLoading ? <CircularProgress size="1rem" /> :props.children}
        </StyledButton>
    );
}

export default Button;

const StyledButton = styled.button`
    border: 2px solid grey;
    border-radius: 4px;
    height: 40px;
    width: 100px;
    &:hover {
        background-color: darkgrey;
    }
`;