import styled from "styled-components";

export const HomeFifWrap = styled.div`
  display: flex;
  z-index: -2;
  align-items: center;
  flex-direction: column;
  width: 100%;
  padding-top: 80px;
  padding-bottom: 243px;
  margin-left: auto;
  margin-right: auto;
  text-align: center;

  @media only screen and (max-width: 800px) {
    padding-bottom: 0;
    padding-top: 0;
  }
`;

export const HomeFifItems = styled.div`
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  row-gap: 36px;
  gap: 78px;
  width: 100%;
  max-width: 1200px;
  margin-top: 100px;

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    row-gap: 40px;
    width: auto;
    margin-top: 0;
  }
`;
