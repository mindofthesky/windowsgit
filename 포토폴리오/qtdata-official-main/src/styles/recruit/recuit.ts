import styled from "styled-components";
import { theme } from "../../themes/themes";

export const RecruitWrap = styled.div`
  overflow-y: auto;
  overflow-x: auto;
  background-color: ${theme.colors.white};
`;

export const RecruitContainer = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  row-gap: 80px;
  width: 100vw;
  padding-top: 180px;
  padding-bottom: 244px;

  @media only screen and (max-width: 800px) {
    align-items: center;
    row-gap: 40px;
    width: 90%;
    padding-top: 140px;
    padding-bottom: 80px;
    margin-left: auto;
    margin-right: auto;
  }
`;

export const HeadlineBox = styled.div`
  text-align: center;
`;

export const RecruitCategoryWrap = styled.div`
  margin: 24px 0 12px 0;
`;

export const RecruitItemWrap = styled.div`
  overflow: hidden;
  display: flex;
  align-items: center;
  flex-wrap: wrap;
  max-width: 1440px;
  padding-bottom: 80px;

  & > div {
    margin-bottom: 24px;
    font-weight: 700;
  }

  @media only screen and (max-width: 800px) {
    flex-direction: column;
    align-content: center;
    padding-bottom: 0px;
  }
`;

export const RecruitItems = styled.div`
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  gap: 24px;
  max-width: 1440px;
  width: 100%;

  @media only screen and (max-width: 800px) {
    justify-content: center;
    flex-direction: column;
  }
`;

export const RecruitItemBox = styled.div`
  flex: 0 0 calc(30% - 24px);
  flex-direction: column;
  align-items: center;
  gap: 20px;
  margin-bottom: 24px;
  padding: 40px 30px;
  border-radius: 12px;
  border: 1px solid #d7d7d7;

  &:nth-child(3n + 1) {
    margin-left: 0;
  }

  &:nth-child(3n + 2) {
    margin-left: 24px;

    @media only screen and (max-width: 800px) {
      margin-left: 0px;
    }
  }

  &:nth-child(3n) {
    margin-right: 0;
  }

  @media only screen and (max-width: 800px) {
    width: 100%;
    max-width: none;
    margin: 0;
    padding: 20px;
  }
`;

export const RecruitBtnWrap = styled.div`
  display: flex;
  justify-content: center;

  @media only screen and (max-width: 800px) {
    gap: 16px;
  }
`;

export const RecruitBtn = styled.div`
  display: inline-flex;
  justify-content: center;
  align-items: center;
  flex-shrink: 0;
  gap: 4px;
  height: 68px;
  padding: 18px 24px;
  margin: 0 20px;
  font-size: 20px;
  font-weight: 700;
  line-height: 28px;
  border-radius: 8px;

  @media only screen and (max-width: 800px) {
    height: 36px;
    padding: 6px 12px;
    font-size: 12px;
    margin: 0;
  }
`;

export const JobBtn = styled(RecruitBtn)`
  background-color: #b8ff00;
  color: #1700ff;
`;

export const JobImg = styled.img`
  width: 103px;
  height: 24px;

  @media only screen and (max-width: 800px) {
    width: 61px;
    height: 14px;
  }
`;

export const SaramBtn = styled(RecruitBtn)`
  align-items: center;
  background-color: #e5e7eb;
  color: #404040;
`;

export const SaramImg = styled.img`
  width: 99px;
  height: 25px;

  @media only screen and (max-width: 800px) {
    width: 54px;
    height: 14px;
  }
`;

export const RecruitTabs = styled.div`
  overflow: auto;
  display: flex;
  justify-content: center;
  gap: 16px;

  @media only screen and (max-width: 800px) {
    overflow-x: auto;
    display: inline-flex;
    align-items: flex-start;
    gap: 8px;
    width: 100%;
    padding-left: 0.2rem;

    &::-webkit-scrollbar {
      display: none;
    }
  }

  @media only screen and (max-width: 420px) {
    padding-left: 0.8rem;
  }

  @media only screen and (max-width: 380px) {
    padding-left: 28px;
  }
`;

interface RecruitTabProps {
  $isselected: boolean;
}

export const RecruitTab = styled.button<RecruitTabProps>`
  padding: 10px 20px;
  font-size: 20px;
  border-radius: 8px;
  background-color: ${(props) =>
    props.$isselected ? `${theme.colors.primary}` : `${theme.colors.enable}`};
  color: ${theme.colors.sub};
  border: none;
  cursor: pointer;
  transition: all 0.2s ease-out;

  &:hover {
    transition: all 0.2s ease-out;
    background-color: ${theme.colors.primary};
  }

  @media only screen and (max-width: 800px) {
    padding: 8px 12px;
    font-size: 12px;
    line-height: 20px;
  }
`;

export const RecruitItemName = styled.p`
  margin-bottom: 20px;
  text-align: left;
  font-size: 20px;
  font-style: normal;
  font-weight: 700;
  line-height: 28px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    margin-bottom: 8px;
    font-size: 14px;
    font-weight: 600;
  }
`;

export const RecruitItemDesc = styled.p`
  font-size: 16px;
  font-style: normal;
  font-weight: 400;
  line-height: 28px;
  color: ${theme.colors.sub};

  @media only screen and (max-width: 800px) {
    font-size: 12px;
    line-height: 20px;
    color: #8b8b8b;
  }
`;
