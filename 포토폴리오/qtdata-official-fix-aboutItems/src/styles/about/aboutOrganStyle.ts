import styled from "styled-components";

export const OrganWrap = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  width: 100%;
  margin-top: 160px;

  @media only screen and (max-width: 800px) {
    margin-top: 100px;
    margin-left: auto;
    margin-right: auto;
  }
`;

export const OrganBox = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-shrink: 0;
  width: 1296px;
  height: 838px;
  margin-top: 160px;

  @media only screen and (max-width: 800px) {
    align-items: center;
    row-gap: 40px;
    margin-top: 0px;
  }
`;

export const OrganImg = styled.img`
  margin: 36px auto;

  @media only screen and (max-width: 800px) {
    display: none;
  }
`;

export const MOrganImg = styled.img`
  display: none;

  @media only screen and (max-width: 800px) {
    display: block;
    flex-shrink: 0;
    width: 327px;
    height: 542px;
  }
`;
