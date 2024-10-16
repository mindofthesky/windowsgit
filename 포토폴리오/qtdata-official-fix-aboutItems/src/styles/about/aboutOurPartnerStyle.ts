import styled from "styled-components";

export const PartnerWrap = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  row-gap: 80px;
  width: 100%;
  padding-top: 160px;
  padding-bottom: 80px;

  @media only screen and (max-width: 800px) {
    width: 88%;
    padding-top: 0;
    margin-left: auto;
    margin-right: auto;
  }
`;

export const Partners = styled.div`
  display: flex;
  flex-wrap: wrap;
  gap: 3.75rem 1.5rem;
  max-width: 1440px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    gap: 1.5rem;
  }
`;

export const PartnerImg = styled.img`
  flex: 1;
  max-width: calc(25% - 1.125rem);
  height: 100%;
  object-fit: contain;

  @media only screen and (max-width: 800px) {
    max-width: calc(50% - 0.75rem);
  }
`;

export const HiddenDiv = styled.div`
  display: none;
  width: 100%;
  height: 8px;

  @media only screen and (max-width: 800px) {
    display: block;
  }
`;
