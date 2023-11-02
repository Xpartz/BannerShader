#ifndef GETDEGREES_INCLUDED
#define GETDEGREES_INCLUDED

void getDegrees_half(float3 VectorX, float3 VectorZ, out float Degrees) {


            // ��������� ��������� ������������ ��������
            float dotProduct = dot(VectorX, VectorZ);

            // ��������� ����� ��������
            float lengthX = length(VectorX);
            float lengthZ = length(VectorZ);

            // ��������� ���� � ��������
            float cosTheta = dotProduct / (lengthX * lengthZ);
            float thetaRadians = acos(cosTheta);

            // ���������� ���� � �������
            Degrees = degrees(thetaRadians);



       
}
#endif