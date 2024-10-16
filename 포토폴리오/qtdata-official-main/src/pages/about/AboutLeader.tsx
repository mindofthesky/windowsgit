import React from 'react';
import parse from 'html-react-parser';
import { aboutMembers } from '../../datas/aboutItems';
import { TMemberData } from '../../types/aboutTypes';
import {
  AboutCeo,
  AboutDetail,
  AboutDetailBox,
  AboutLeaderHeadline,
  AboutLeaderInfo,
  AboutName,
  AboutNameWrap,
} from '../../styles/about/aboutLeaderStyle';

const AboutLeader = ({ infoMembers }: { infoMembers: TMemberData[] }) => {
  if (aboutMembers.length === 0) {
    return null;
  }

  const leader = infoMembers[0];

  return (
    <AboutLeaderInfo>
      <div>
        <AboutLeaderHeadline>{leader.members[0].slogan}</AboutLeaderHeadline>
      </div>
      <AboutNameWrap>
        <AboutName>{leader.members[0].name}</AboutName>
        <AboutCeo>{leader.members[0].position}</AboutCeo>
      </AboutNameWrap>
      <AboutDetailBox>
        <AboutDetail>{parse(leader.members[0].career)}</AboutDetail>
      </AboutDetailBox>
    </AboutLeaderInfo>
  );
};

export default AboutLeader;
