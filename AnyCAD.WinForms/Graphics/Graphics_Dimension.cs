﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCAD.Forms;
using AnyCAD.Foundation;

namespace AnyCAD.Demo.Graphics
{
    class Graphics_Dimension : TestCase
    {
        public override void Run(RenderControl render)
        {
            GPntList points = new GPntList();
            points.Add(new GPnt(-100, 0, 0));
            points.Add(new GPnt(100, 0, 0));
            points.Add(new GPnt(0, 100, 0));

            var shape = SketchBuilder.MakePolygon(points, true);
            render.ShowShape(shape, ColorTable.Red);

            var dim1 = new AlignedDimensionNode(new Vector3(-100,0,0), new Vector3(0,100,0), 20, Vector3.UNIT_Z, "长度");
            dim1.GetMaterial().SetColor(ColorTable.Green);
            dim1.Update();
            render.ShowSceneNode(dim1);

            var dim2 = new LinearDimensionNode(new Vector3(100, 0, 0), new Vector3(0, 100, 0), new Vector3(120, 0, 0), -90, "高度");
            dim2.Update();
            render.ShowSceneNode(dim2);


            var angle = new AngularDimensionNode(new Vector3(-100, 0, 0), new Vector3(-50, 0, 0), new Vector3(-50, 50, 0), "45");
            angle.Update();
            render.ShowSceneNode(angle);

            var circle = SketchBuilder.MakeCircle(GP.Origin(), 25, GP.DZ());
            render.ShowShape(circle, ColorTable.Beige);

            var radiusDim = new RadiusDimensionNode(new Vector3(0), 25, 45, 15, "R25");
            radiusDim.Update();

            render.ShowSceneNode(radiusDim);
        }

    }
}
