import styled from "styled-components";
import { theme } from "../../themes/themes";

export const AboutLeaderMembers = styled.div`
  position: absolute;
  align-self: flex-end;
  right: 0;
  top: 0px;
  width: 100%;

  @media only screen and (max-width: 1440px) {
    position: initial;
  }
`;

export const ListUl = styled.div`
  display: flex;
  margin-left: -0.75%;
`;

export const AboutListLayout = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
`;

export const AboutLeaderRows = styled.div`
  display: flex;
  justify-content: flex-end;
  width: 100%;
`;

export const AboutRows = styled(AboutLeaderRows)`
  margin-bottom: 10px;
`;

export const AboutLeaderList = styled.div`
  position: absolute;
  left: 0;
  margin-left: 0;
  height: 100%;
`;

export const AboutThumbInfoWrap = styled.div`
  position: absolute;
  z-index: 2;
  top: 0;
  left: 0;
  display: none;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100%;
  text-align: center;
`;

export const AboutThumb = styled.div`
  position: relative;
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
  height: 100%;

  &:hover {
    cursor: pointer;

    ${AboutThumbInfoWrap} {
      display: flex;
    }

    &::before {
      content: "";
      position: absolute;
      z-index: 1;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background: rgba(0, 0, 0, 0.5);
    }
  }

  > img {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }
`;

export const AboutInfoBox = styled.div`
  z-index: 1;
`;

export const AboutNick = styled.div`
  font-size: 24px;

  font-style: normal;
  font-weight: 500;
  line-height: 40px;
  color: ${theme.colors.white};
`;

export const AboutPosition = styled.div`
  font-size: 18px;
  font-style: normal;
  font-weight: 500;
  line-height: 40px;
  color: ${theme.colors.enable};
`;

export const AboutMemberList = styled.div`
  position: relative;
  z-index: 8;
  flex-basis: 0;
  margin-left: 10px;
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  user-select: none;
`;

export const AboutMemberThumb = styled.div<{ $backgroundImage: string }>`
  position: relative;
  background-image: url(${(props) => props.$backgroundImage});
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
  width: 200px;
  height: 240px;

  &:hover {
    cursor: pointer;

    ${AboutThumbInfoWrap} {
      display: flex;
    }

    &::before {
      content: "";
      position: absolute;
      z-index: 1;
      top: 0;
      left: 0;
      background: rgba(0, 0, 0, 0.5);
      width: 100%;
      height: 100%;
    }
  }
`;
