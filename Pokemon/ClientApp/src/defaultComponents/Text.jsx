import React from 'react';
import { Container } from 'reactstrap';
import styled from 'styled-components';

const Text = (props) => {

    const getText = () => {
        if(props.type === "large") {
            return (
                <LargeText>{props.children}</LargeText>
            );
        } else if(props.type === "medium") {
            return (
                <MediumText>{props.children}</MediumText>
            );
        } else {
            return (
                <SmallText>{props.children}</SmallText>
            );
        }
    }

    return (
        <Container style={props.isWarning ? { color:'red' } : {}}>
            {getText()}
        </Container>
    );
}

export default Text;

const LargeText = styled.p`
    font-size: 2.5rem;
    font-weight: 500;
`;

const MediumText = styled.p`
    font-size: 18px;
`;

const SmallText = styled.p`
    font-size: 14px;
`;